from typing import TypeVar, Generic
from dataclasses import dataclass
from pydantic import BaseModel

from app.core.pagination import PaginationMetadata

T = TypeVar('T', bound=BaseModel)

@dataclass
class ApiResponse(Generic[T]):
    data: T | tuple[T, ...] | None = None

@dataclass
class ApiPaginatedResponse(Generic[T]):
    data: tuple[T, ...] = tuple()
    current_page: int | None = None
    total_pages: int | None = None
    total_count: int | None = None
    page_size: int | None = None

    def __init__(
        self,
        pagination: PaginationMetadata | None,
        data: tuple[T, ...] = tuple(),
    ):
        self.data = data
        
        if pagination:
            self.current_page = pagination.current_page
            self.total_pages = pagination.total_pages
            self.total_count = pagination.total_count
            self.page_size = len(self.data)
